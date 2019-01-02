
namespace materialDesignTesting
{
    //<summary> An Enum type that is used to track the progress within the wizard,
    //used to assist in the implemenation of the Expanders 
    //    Author: Alex Zeltser</summary>
    //<retrun>int value of blank,loaded and manual</return>
    public enum progress:int
    {
        blank   = 0,
        loaded  = 1,
        manual  = 2,
    };
}
