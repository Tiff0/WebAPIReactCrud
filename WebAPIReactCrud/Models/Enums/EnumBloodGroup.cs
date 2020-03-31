using System.ComponentModel;

namespace WebAPIReactCrud.Models.Enums
{
    public enum EnumBloodGroup : int
    {
        /// <summary>
        /// A : 1
        /// </summary>
        [Description(@"A")]
        A = 1,		  
			
        /// <summary>
        /// B : 2
        /// </summary>
        [Description(@"B")]
        B = 2,		  
			
        /// <summary>
        /// AB : 3
        /// </summary>
        [Description(@"AB")]
        AB = 3,		  
			
        /// <summary>
        /// O : 4
        /// </summary>
        [Description(@"O")]
        O = 4,	
    }
}