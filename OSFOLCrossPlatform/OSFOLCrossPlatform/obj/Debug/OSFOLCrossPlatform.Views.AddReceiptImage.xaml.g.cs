//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OSFOLCrossPlatform.Views {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class AddReceiptImage : global::Xamarin.Forms.ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button TakePicture;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button SelectPicture;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button AddExpense;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Label ReceiptImageUri;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Image ReceiptImage;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(AddReceiptImage));
            TakePicture = this.FindByName<global::Xamarin.Forms.Button>("TakePicture");
            SelectPicture = this.FindByName<global::Xamarin.Forms.Button>("SelectPicture");
            AddExpense = this.FindByName<global::Xamarin.Forms.Button>("AddExpense");
            ReceiptImageUri = this.FindByName<global::Xamarin.Forms.Label>("ReceiptImageUri");
            ReceiptImage = this.FindByName<global::Xamarin.Forms.Image>("ReceiptImage");
        }
    }
}
