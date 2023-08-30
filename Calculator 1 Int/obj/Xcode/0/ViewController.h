// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface ViewController : NSViewController {
	//NSTextField *_txt_label;
    __weak IBOutlet NSTextField *txt_label;
    NSTextField *_TxtBox;
}

@property (nonatomic, retain) IBOutlet NSTextField *txt_label;

@property (nonatomic, retain) IBOutlet NSTextField *TxtBox;

- (IBAction)OnlyNumbers:(NSButton *)sender;

- (IBAction)btn_clearAll:(NSButton *)sender;
- (IBAction)btn_delete:(NSButton *)sender;

- (IBAction)btn_clearEntry:(NSButton *)sender;
- (IBAction)btn_dot:(NSButton *)sender;

- (IBAction)btnOperators:(NSButton *)sender;


//- (IBAction)btn_division:(NSButton *)sender;
//
//- (IBAction)btn_multiplication:(NSButton *)sender;
//- (IBAction)btn_plus:(NSButton *)sender;
//
//- (IBAction)btn_porcent:(NSButton *)sender;
//- (IBAction)btn_subtraction:(NSButton *)sender;

- (IBAction)btn_total:(NSButton *)sender;

@end
