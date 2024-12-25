using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Loyc.Syntax;
using Loyc.Collections;
using Loyc.Utilities;

namespace Loyc.LLParserGenerator
{
	/// <summary>
	/// A class that implements this interface will generate small bits of code 
	/// that the parser generator will use. The default implementation is
	/// <see cref="IntStreamCodeGenHelper"/>. To install a new code generator,
	/// set the <see cref="LLParserGenerator.CodeGenHelper"/> property or
	/// supply the generator in the constructor of <see cref="LLParserGenerator"/>.
	/// </summary>
	/// <remarks>Two of these methods (VisitInput and FromCode) are called by the
	/// LLLPG macro. All the others are called by the main engine and its helper
	/// classes in <see cref="LLParserGenerator"/>.
	/// <para/>
	/// Note that some parts of the code (the outer skeleton--if, while, for 
	/// statements) are still generated by LLParserGenerator.GenerateCodeVisitor.
	/// </remarks>
	public interface IPGCodeGenHelper
	{
		/// <summary>Returns an empty set of the appropriate type for the kind of 
		/// parser being generated by this code.</summary>
		IPGTerminalSet EmptySet { get; }

		/// <summary>In case the IPGCodeGenHelper is interested, the LLLPG macro 
		/// calls this method on each statement in the body of the macro (as a 
		/// preprocessing step, before LLLPG looks at it). No action is required.</summary>
		/// <returns>a new statement to replace the original statement, or null to 
		/// do nothing.</returns>
		LNode VisitInput(LNode stmt, IMessageSink sink);

		/// <summary>Creates a terminal predicate from a code expression.</summary>
		/// <param name="expr">A expression provided by the user, such as <c>"a string"</c>,
		/// a <c>Token.Type</c>, or a <c>value..range</c>. <c>expr</c> will not be
		/// a call to the inversion operator #~ (that's handled internally using 
		/// <see cref="IPGTerminalSet.Inverted()"/>). This method also handles the
		/// "any token" input, which is an underscore by convention (_).</param>
		/// <param name="errorMsg">An error message to display. If the method 
		/// returns null, the LLLPG macro shows this as an error; if this method does 
		/// not return null, the message (if provided) is shown as a warning.</param>
		/// <returns>If successful, a terminal predicate; otherwise null.</returns>
		Pred CodeToTerminalPred(LNode expr, ref string errorMsg);

		/// <summary>Simplifies the specified set, if possible, so that GenerateTest() 
		/// can generate simpler code for an if-else chain in a prediction tree.</summary>
		/// <param name="set"></param>
		/// <param name="dontcare">A set of terminals that have been ruled out,
		/// i.e. it is already known that the lookahead value is not in this set.</param>
		/// <returns>An optimized set, or this.</returns>
		IPGTerminalSet Optimize(IPGTerminalSet set, IPGTerminalSet dontcare);

		/// <summary>Returns an example of a character in the set, or null if this 
		/// is not a set of characters or if EOF is the only member of the set.</summary>
		/// <remarks>This helps produce error messages in LLLPG.</remarks>
		char? ExampleChar(IPGTerminalSet set);
		/// <summary>Returns an example of an item in the set. If the example is
		/// a character, it should be surrounded by single quotes.</summary>
		/// <remarks>This helps produce error messages in LLLPG.</remarks>
		string Example(IPGTerminalSet set);

		/// <summary>Before the parser generator generates code, it calls this
		/// method.</summary>
		/// <param name="classBody">the body (braced block) of the class where 
		/// the code will be generated, which allows the snippet generator to add 
		/// code at class level when needed.</param>
		/// <param name="sourceFile">the suggested <see cref="ISourceFile"/> to 
		/// assign to generated code snippets.</param>
		void Begin(WList<LNode> classBody, ISourceFile sourceFile);

		/// <summary>Notifies the snippet generator that code generation is 
		/// starting for a new rule.</summary>
		void BeginRule(Rule rule);

		/// <summary><see cref="LLParserGenerator"/> calls this method to notify
		/// the snippet generator that code generation is complete.</summary>
		void Done();

		/// <summary>Generate code to match any token.</summary>
		/// <returns>Default implementation returns <c>@{ Skip(); }</c>, or 
		/// @{ MatchAny(); } if the result is to be saved.</returns>
		LNode GenerateSkip(bool savingResult);

		/// <summary>Generate code to check an and-predicate during or after prediction, 
		/// e.g. <c>&amp;!{foo}</c> becomes <c>!(foo)</c> during prediction and 
		/// <c>Check(!(foo));</c> afterward.</summary>
		/// <param name="andPred">Predicate for which an expression has already been generated</param>
		/// <param name="code">The expression to be checked</param>
		/// <param name="lookaheadAmt">Current lookahead amount. -1 means 
		/// "prediction is complete, generate a Check() statement".</param>
		/// <remarks>LLLPG substitutes $LI and $LA before it calls this method.</remarks>
		LNode GenerateAndPredCheck(AndPred andPred, LNode code, int lookaheadAmt);

		/// <summary>Generate code to match a set, e.g. 
		/// <c>@{ MatchRange('a', 'z');</c> or <c>@{ MatchExcept('\n', '\r'); }</c>.
		/// If the set is too complex, a declaration for it is created in the
		/// <c>classBody</c> which was passed to <c>Begin()</c>.</summary>
		LNode GenerateMatch(IPGTerminalSet set_, bool savingResult, bool recognizerMode);

		/// <summary>Generates code to read LA(k).</summary>
		/// <returns>The default implementation returns @(LA(k)).</returns>
		LNode LA(int k);

		/// <summary>Returns the data type of LA(k)</summary>
		/// <returns>The default implementation returns @(int).</returns>
		LNode LAType();

		/// <summary>Generates code for the error branch of prediction.</summary>
		/// <param name="covered">The permitted token set, which the input did not match. 
		/// NOTE: if the input matched but there were and-predicates that did not match,
		/// this parameter will be null (e.g. the input is 'b' in <c>(&amp;{x} 'a' | &amp;{y} 'b')</c>,
		/// but y is false).</param>
		/// <param name="laIndex">Lookahead amount at which the error branch is being created.</param>
		LNode ErrorBranch(IPGTerminalSet covered, int laIndex);

		/// <summary>Returns true if a "switch" statement is the preferable code 
		/// generation technique rather than the default if-else chain</summary>
		/// <param name="branchSets">Non-overlapping terminal sets, one set for each 
		/// branch of the prediction tree.</param>
		/// <param name="casesToInclude">To this set, this method should add the 
		/// indexes of branches for which case labels should be generated, e.g.
		/// adding index 2 means that switch cases should be generated for sets[2].
		/// The caller (<see cref="LLParserGenerator"/>) will create an if-else 
		/// chain for all branches that are not added to casesToInclude, and this 
		/// chain will be passed to <see cref="GenerateSwitch"/>.</param>
		/// <remarks>
		/// Using a switch() statement can be important for performance, since the
		/// compiler may be able to implement a switch statement using as little as
		/// a single branch, unlike an if-else chain which often requires multiple
		/// branches.
		/// <para/>
		/// However, it does not always make sense to use switch(), and when it does 
		/// make sense, it may not be wise or possible to include all cases in the
		/// switch, so this method is needed to make the decision.
		/// <para/>
		/// Consider an example with four branches, each having a character set, 
		/// plus an error branch:
		/// <pre>
		///     Branch 1: '*'|'+'|'-'|'/'|'%'|'^'|'&amp;'|','|'|'
		///     Branch 2: '_'|'$'|'a'..'z'|'A'..'Z'|128..65535
		///     Branch 3: '0'..'9'
		///     Branch 4: ' '|'\t'
		///     Error: anything else
		/// </pre>
		/// In this case, it is impossible (well, quite impractical) to use cases 
		/// for all of Branch 2. The most sensible switch() statement probably looks 
		/// like this:
		/// <pre>
		///     switch(la0) {
		///     case '*': case '+': case '-': case '/': case '%':
		///     case '^': case '&amp;': case ',': case '|':
		///         // branch 1
		///     case '0': case '1': case '2': case '3': case '4': 
		///     case '5': case '6': case '7': case '8': case '9': 
		///         // branch 3
		///     case ' ': case '\t':
		///         // branch 4
		///     default:
		///         if (la0 >= 'A' &amp;&amp; la0 &lt;= 'Z' || la0 >= 'a' &amp;&amp; la0 &lt;= 'z' || la0 >= 128 &amp;&amp; la0 &lt;= 65536)
		///             // branch 2
		///         else
		///             // error
		///     }
		/// </pre>
		/// Please note that given LLLPG's current design, it is not possible to "split" a 
		/// branch. For example, the switch cannot include "case '_': case '$':" and use this
		/// to handle branch 2 (but not the error case), while also handling branch 2 in the
		/// "default" case. Although LLLPG has a mechanism to duplicate branches of an 
		/// <see cref="Alts"/> so that the code for handling an alternative is located at 
		/// two different places in a prediction tree (using 'goto' if necessary), it does 
		/// not have a similar mechanism for arbitrary subtrees of a prediction tree.
		/// <para/>
		/// 'sets' does not include the error branch, if any. If there's no error branch, the
		/// last case should be left out of 'casesToInclude' so that there will be a 
		/// 'default:' case. Note: it should always be the <i>last</i> set that is left
		/// out, because that will be the official default branch (the user can control
		/// which branch is default, hence which one comes last, using the 'default' keyword
		/// in the grammar DSL.)
		/// </remarks>
		bool ShouldGenerateSwitch(IPGTerminalSet[] branchSets, MSet<int> casesToInclude, bool hasErrorBranch);

		/// <summary>Generates a switch statement with the specified branches where
		/// branchCode[i] is the code to run if the input is in the set branchSets[i].</summary>
		/// <param name="casesToInclude">The set chosen by <see cref="ShouldGenerateSwitch"/>.</param>
		/// <param name="defaultBranch">Code to be placed in the default: case, or the empty identifier (@``) if none</param>
		/// <param name="laVar">The lookahead variable being switched on (e.g. la0)</param>
		/// <returns>The generated switch block.</returns>
		LNode GenerateSwitch(IPGTerminalSet[] branchSets, LNode[] branchCode, MSet<int> casesToInclude, LNode defaultBranch, LNode laVar);

		/// <summary>Generates code to test whether the terminal denoted 'laVar' is in the set.</summary>
		LNode GenerateTest(IPGTerminalSet set, LNode laVar);

		/// <summary>Generates the method for a rule, given the method's contents.</summary>
		/// <param name="rule">Rule for which a method is needed.</param>
		/// <param name="methodBody">A list of statements produced by 
		/// LLParserGenerator inside the method.</param>
		/// <returns>A method definition for the rule.</returns>
		LNode CreateRuleMethod(Rule rule, LNodeList methodBody);

		/// <summary>Generates the try-wrapper for a recognizer rule.</summary>
		/// <remarks>
		/// To generate the default method, simply call <c>rule.CreateTryWrapperForRecognizer()</c>.
		/// <para/>
		/// Recognizers consist of two methods: the recognizer itself and the
		/// try-wrapper, if it is needed by the grammar. For example, the 
		/// recognizer version of this rule:
		/// <code>
		///   rule Hello @{ "hi" { _foo++; } };
		/// </code>
		/// is this pair of methods:
		/// <code>
		///   bool Try_Scan_Hello() {
		///     using (new SavedPosition(this))
		///       return Scan_Hello();
		///   }
		///   bool Scan_Hello() {
		///     if (!TryMatch('h'))
		///       return false;
		///     if (!TryMatch('i'))
		///       return false;
		///     return true;
		///   }
		/// </code>
		/// The <c>Try_*</c> helper method is called from normal rules that use an 
		/// zero-width assertion (<c>&amp;Hello</c>), while the recognizer method 
		/// <c>Scan_*</c> is called from other recognizers that call the rule normally 
		/// (i.e. NOT using an and-predicate). By the way, the LLLPG core removes
		/// actions like <c>_foo++</c> from the recognizer version.
		/// <para/>
		/// </remarks>
		LNode CreateTryWrapperForRecognizer(Rule rule);

		/// <summary>Generates code to call a rule based on <c>rref.Rule.Name</c>
		/// and <c>rref.Params</c>.</summary>
		/// <returns>
		/// For a normal rule call, this method should return 
		/// <c>rref.AutoSaveResult(code)</c> where <c>code</c> is the code to 
		/// invoke the rule.
		/// <para/>
		/// Recognizer mode is normally implemented by calling the recognizer 
		/// version of the rule in an "if" statement: <c>if (!Scan_Foo()) return false;</c>
		/// <para/>
		/// Backtrack mode expects a boolean expression to be returned, normally 
		/// something like <c>Try_Scan_Foo()</c> where the name <c>Try_Is_Foo</c> 
		/// comes from the recognizer's <see cref="Rule.TryWrapperName"/>.
		/// </returns>
		LNode CallRule(RuleRef rref, bool recognizerMode);

		/// <summary>Generates a call to the Try_Scan_*() function that wraps around 
		/// a Scan_*() recognizer. Called while generating code for an and-pred.</summary>
		LNode CallTryRecognizer(RuleRef rref, int lookahead);

		/// <summary>Type of variables auto-declared when you use labels in your
		/// grammar (e.g. x:Foo (list+:Bar)*)</summary>
		LNode TerminalType { get; }

		/// <summary>Gets the list type for elements of the specified type (e.g. List&lt;type>)</summary>
		LNode GetListType(LNode type);

		/// <summary>Gets a variable declaration for the specified type, e.g. if 
		/// type is <c>Foo</c> and <c>wantList == true</c> and <c>varName.Name == "x"</c>, 
		/// the statement returned might be <c>List&lt;Foo> x = new List&lt;Foo>();</c></summary>
		LNode MakeInitializedVarDecl(LNode type, bool wantList, Symbol varName);

		/// <summary>Returns the node for an alias. If the specified node is not an 
		/// alias, returns the same node unchanged.</summary>
		LNode ResolveAlias(LNode node);
	}
}
