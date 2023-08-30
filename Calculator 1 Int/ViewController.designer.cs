// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Calculator_1_Int
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField txt_label { get; set; }

		[Outlet]
		AppKit.NSTextField TxtBox { get; set; }

		[Action ("btn_clearAll:")]
		partial void btn_clearAll (AppKit.NSButton sender);

		[Action ("btn_clearEntry:")]
		partial void btn_clearEntry (AppKit.NSButton sender);

		[Action ("btn_delete:")]
		partial void btn_delete (AppKit.NSButton sender);

		[Action ("btn_dot:")]
		partial void btn_dot (AppKit.NSButton sender);

		[Action ("btn_multiplication:")]
		partial void btn_multiplication (AppKit.NSButton sender);

		[Action ("btn_plus:")]
		partial void btn_plus (AppKit.NSButton sender);

		[Action ("btn_porcent:")]
		partial void btn_porcent (AppKit.NSButton sender);

		[Action ("btn_subtraction:")]
		partial void btn_subtraction (AppKit.NSButton sender);

		[Action ("btn_total:")]
		partial void btn_total (AppKit.NSButton sender);

		[Action ("btnOperators:")]
		partial void btnOperators (AppKit.NSButton sender);

		[Action ("OnlyNumbers:")]
		partial void OnlyNumbers (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txt_label != null) {
				txt_label.Dispose ();
				txt_label = null;
			}

			if (TxtBox != null) {
				TxtBox.Dispose ();
				TxtBox = null;
			}
		}
	}
}
