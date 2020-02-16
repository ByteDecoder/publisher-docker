﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'void Program.Main()' passes a literal string as parameter 'value' of a call to 'void Console.WriteLine(string value)'. Retrieve the following string(s) from a resource table instead: \"Posting a message!\".", Justification = "<Pending>", Scope = "member", Target = "~M:Worker.Program.Main")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:Worker.Program.PostMessage(System.String)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2234:Modify 'Program.PostMessage(string)' to call 'HttpClient.PostAsync(Uri, HttpContent)' instead of 'HttpClient.PostAsync(string, HttpContent)'.", Justification = "<Pending>", Scope = "member", Target = "~M:Worker.Program.PostMessage(System.String)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2000:Call System.IDisposable.Dispose on object created by 'new StringContent(json, Encoding.UTF8, \"application/json\")' before all references to it are out of scope.", Justification = "<Pending>", Scope = "member", Target = "~M:Worker.Program.PostMessage(System.String)~System.Threading.Tasks.Task")]