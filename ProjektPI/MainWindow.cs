﻿using System;
using Gtk;
using Mono.Data.Sqlite;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
