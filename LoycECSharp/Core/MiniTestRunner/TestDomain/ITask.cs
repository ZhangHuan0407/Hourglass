﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MiniTestRunner.TestDomain
{
	/// <summary>Task interface needed by TaskRunner and the GUI</summary>
	public interface ITestTask : IPropertyChanged, ITask
	{
		new int Priority { get; set; } // add setter (ITask has only a getter)
		TestStatus Status { get; }
		DateTime LastRunAt { get; }
		TimeSpan RunTime { get; }
	}

	/// <summary>Task interface needed by TaskRowModel</summary>
	public interface ITaskEx : ITestTask
	{
		Stream OutputStream { get; set; }
		IList<RowModel> Children { get; }
		string Summary { get; }
		string AssemblyPath { get; }
		AppDomain Domain { get; }
	}
}
