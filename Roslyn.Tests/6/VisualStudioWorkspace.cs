// protected override void Initialize()
// { 
//     //Other stuff...
//     ...

//     var componentModel = (IComponentModel)this.GetService(typeof(SComponentModel));
//     var workspace = componentModel.GetService<Microsoft.VisualStudio.LanguageServices.VisualStudioWorkspace>();
// }

// //Alternatively you can MEF import the workspace. MEF can be tricky if you're not familiar with it
// //but here's how you'd import VisuaStudioWorkspace as a property.

// [Import(typeof(Microsoft.VisualStudio.LanguageServices.VisualStudioWorkspace))]
// public VisualStudioWorkspace myWorkspace { get; set; }