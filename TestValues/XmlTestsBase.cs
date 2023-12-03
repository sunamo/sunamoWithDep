public class XmlTestsBase
{
    protected string pathXlf = @"D:\_Test\sunamo\sunamo\XH\xlf.xml";

    /// <summary>
    /// All XML for testing must be in c#, here 
    /// </summary>
    protected string xml1 = @"<Cell>          
    <CellContent>
        <Para>                               
            <ParaLine>                      
                <String>ABCabcABC abcABC abc ABCABCABC.</String> 
            </ParaLine>                      
        </Para>     
    </CellContent>
</Cell>";

        /// <summary>
    /// All XML for testing must be in c#, here 
    /// </summary>
    protected string xml2 = @"<Cell>          
    <CellContent>
        <Para>                               
            <ParaLine>                      
                <String>ABCabcABC abcABC abc ABCABCABC.</String> 
            </ParaLine>                      
        </Para>    
<Para>                               
            <ParaLine>                      
                <String>ABCabcABC abcABC abc ABCABCABC.</String> 
            </ParaLine>                      
        </Para> 
    </CellContent>
</Cell>";

        /// <summary>
    /// All XML for testing must be in c#, here 
    /// </summary>
    protected string xml2WithAttr = @"<Cell Sdk='a'>          
    <CellContent>
        <Para>                               
            <ParaLine>                      
                <String>ABCabcABC abcABC abc ABCABCABC.</String> 
            </ParaLine>                      
        </Para>    
<Para>                               
            <ParaLine>                      
                <String>ABCabcABC abcABC abc ABCABCABC.</String> 
            </ParaLine>                      
        </Para> 
    </CellContent>
</Cell>";

        /// <summary>
    /// All XML for testing must be in c#, here 
    /// </summary>
    protected string Xml2WithAttr2 = @"<Project Sdk='a'>          
    <PropertyGroup>
        <Version>23.11.6.1</Version>                        
    </PropertyGroup>
    <PropertyGroup>
        <Version>Second</Version>                        
    </PropertyGroup>    
</Project>";

            /// <summary>
    /// All XML for testing must be in c#, here 
    /// </summary>
    protected string Xml2WithAttr3 = @"<Project Sdk='a'>          
    " + "<PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='Debug|AnyCPU'\"" + @">
        <Version>23.11.6.1</Version>                        
    </PropertyGroup>
    <PropertyGroup>
        <Version>Second</Version>                        
    </PropertyGroup>    
</Project>";

        protected string Xml2WithAttr3Add = @"<Project Sdk='a'>          
    " + "<PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='Debug|AnyCPU'\"" + @">
        <Ne>23.11.6.1</Ne>                        
    </PropertyGroup>
    <PropertyGroup>
        <So>Second</So>                        
    </PropertyGroup>    
</Project>";

}
