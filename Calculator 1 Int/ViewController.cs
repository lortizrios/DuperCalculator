using ObjCRuntime;

namespace Calculator_1_Int;

// Clase ViewController que hereda de NSViewController
public partial class ViewController : NSViewController {

    // Constructor de la clase ViewController
    protected ViewController (NativeHandle handle) : base (handle)
	{
		
	}

    // Variables para realizar cálculos
    double result = 0;
    string operation = "";
    bool enter_value = false;

    // Método que se llama cuando la vista carga
    public override void ViewDidLoad ()

	{
		base.ViewDidLoad ();

        // Configuración del view
        TxtBox.Formatter = new NumberOnlyFormatter();
        View.AddSubview(TxtBox);
    }

    // Propiedad RepresentedObject
    public override NSObject RepresentedObject {
        get
        {
            return base.RepresentedObject;
        }
        set
        {
            base.RepresentedObject = value;
        }
    }

    // Clase interna que formatea números aceptando solo caracteres numéricos
    class NumberOnlyFormatter : NSNumberFormatter
    {
        public override bool IsPartialStringValid(string partialString, out string newString, out NSString error)
        {
            newString = partialString;
            error = new NSString("");
            if (partialString.Length == 0)
                return true;
            if (partialString.All(char.IsDigit))
                return true;
            newString = new string(partialString.Where(char.IsDigit).ToArray());
            return false;
        }
    }

    // Método parcial que maneja los botones numéricos
    partial void OnlyNumbers(AppKit.NSButton sender)
    {
        // Limpia el cuadro de texto si es necesario
        if ((TxtBox.StringValue == "0") || (enter_value))
            TxtBox.StringValue = "";
        enter_value = false;

        // Agrega el número o el punto al cuadro de texto
        if (sender.StringValue == ".")
        {
            if (!TxtBox.StringValue.Contains("."))
                TxtBox.StringValue = TxtBox.StringValue + sender.Title;
        }
        else
        {
            TxtBox.StringValue = TxtBox.StringValue + sender.Title;
        }
    }

    // Método parcial que maneja los botones de operadores
    partial void btnOperators(AppKit.NSButton sender)
    {
        if (result != 0)
        {
            btn_total(sender);
            enter_value = true;
            operation = sender.Title;
            txt_label.StringValue = System.Convert.ToString(result) + "   " + operation;
        }
        else
        {
            operation = sender.Title;
            result = Double.Parse(TxtBox.StringValue);
            TxtBox.StringValue = "";
            txt_label.StringValue = System.Convert.ToString(result) + "   " + operation;
        }
    }

    // Método parcial que calcula el resultado total
    partial void btn_total(AppKit.NSButton sender)
    {
        // Limpia el contenido del label
        txt_label.StringValue = "";

        // Utiliza una estructura de conmutación (switch) para realizar la operación en
        // función del operador almacenado
        switch (operation)
        {
            case "+":
                TxtBox.StringValue = (result + Double.Parse(TxtBox.StringValue)).ToString();
                break;
            case "-":
                TxtBox.StringValue = (result - Double.Parse(TxtBox.StringValue)).ToString();
                break;
            case "*":
                TxtBox.StringValue = (result * Double.Parse(TxtBox.StringValue)).ToString();
                break;
            case "%":
                TxtBox.StringValue = (result % Double.Parse(TxtBox.StringValue)).ToString();
                break;
            case "/":
                if (Double.Parse(TxtBox.StringValue) == 0)
                {
                    txt_label.StringValue = "cannot divide by zero";
                    TxtBox.StringValue = "0";
                    result = 0;
                    return;
                }
                TxtBox.StringValue = (result / Double.Parse(TxtBox.StringValue)).ToString();
                break;
            default:
                break;
        }

        // Actualiza el valor de "result" con el nuevo resultado calculado
        result = Double.Parse(TxtBox.StringValue);

        // Reinicia el valor de "operation" ya que la operación ha terminado
        operation = "";
    }

    // Método parcial que maneja el botón de borrar un dígito
    partial void btn_delete(AppKit.NSButton sender)
    {
        if (TxtBox.StringValue.Length > 0)
        {
            TxtBox.StringValue = TxtBox.StringValue.Remove(TxtBox.StringValue.Length - 1, 1);
        }
        if (TxtBox.StringValue == "")
        {
            TxtBox.StringValue = "0";
        }
    }

    // Método parcial que maneja el botón de borrar todo
    partial void btn_clearAll(AppKit.NSButton sender)
    {
        // Pone 0 en el text box
        TxtBox.StringValue = "0";

        // Limpia el contenido de la etiqueta
        txt_label.StringValue = "";
    }

    // Método parcial que maneja el botón de borrar entrada
    partial void btn_clearEntry(AppKit.NSButton sender)
    {
        TxtBox.StringValue = "0";
        result = 0;
    }

    //partial void OneOf_Click(AppKit.NSButton sender)
    //{
    //    Double a = Convert.ToDouble(1.0 / Convert.ToDouble(TxtBox.StringValue));
    //    TxtBox.StringValue = System.Convert.ToString(a);
    //}

    //partial void PlusMinus_Click(AppKit.NSButton sender)
    //{
    //    TxtBox.StringValue = (Double.Parse(TxtBox.StringValue) * -1).ToString();
    //}

    //partial void SqrRoot_Click(AppKit.NSButton sender)
    //{
    //    double sq = Double.Parse(TxtBox.StringValue);
    //    LblShowOps.StringValue = System.Convert.ToString(TxtBox.StringValue);
    //    sq = Math.Sqrt(sq);
    //    TxtBox.StringValue = System.Convert.ToString(sq);
    //}

    //partial void Double_Click(AppKit.NSButton sender)
    //{
    //    Double a = Convert.ToDouble(TxtBox.StringValue) * Convert.ToDouble(TxtBox.StringValue);
    //    TxtBox.StringValue = System.Convert.ToString(a);
    //}
}