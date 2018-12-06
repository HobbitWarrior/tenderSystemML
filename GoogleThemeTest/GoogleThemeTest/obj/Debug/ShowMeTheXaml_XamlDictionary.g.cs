
using System.Collections.Generic;

namespace ShowMeTheXAML
{
    public static class XamlDictionary
    {
        static XamlDictionary()
        {
            XamlResolver.Set("drawers_1", @"<smtx:XamlDisplay Key=""drawers_1"" MaxHeight=""{x:Static system:Double.MaxValue}"" HorizontalContentAlignment=""Stretch"" VerticalAlignment=""Top"" Grid.Column=""0"" Grid.Row=""0"" Grid.RowSpan=""3"" xmlns:smtx=""clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML"">
  <materialDesign:DrawerHost HorizontalAlignment=""Stretch"" VerticalAlignment=""Stretch"" xmlns:materialDesign=""http://materialdesigninxaml.net/winfx/xaml/themes"">
    <materialDesign:DrawerHost.LeftDrawerContent>
      <StackPanel VerticalAlignment=""Stretch"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
        <Button Command=""{x:Static materialDesign:DrawerHost.CloseDrawerCommand}"" CommandParameter=""{x:Static Dock.Left}"" Width=""48"" Height=""48"" HorizontalAlignment=""Left"">
          <materialDesign:PackIcon Kind=""Menu"" />
        </Button>
        <Button Command=""{x:Static materialDesign:DrawerHost.CloseDrawerCommand}"" CommandParameter=""{x:Static Dock.Left}"" HorizontalAlignment=""Left"" Style=""{DynamicResource MaterialDesignFlatButton}"">
                            CLOSE THIS
                        </Button>
        <Button Command=""{x:Static materialDesign:DrawerHost.CloseDrawerCommand}"" HorizontalAlignment=""Left"" Style=""{DynamicResource MaterialDesignFlatButton}"">
                            CLOSE ALL
                        </Button>
      </StackPanel>
    </materialDesign:DrawerHost.LeftDrawerContent>
    <!--Left Menu Controller-->
    <StackPanel Orientation=""Horizontal"" HorizontalAlignment=""Stretch"" VerticalAlignment=""Top"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
      <Button Command=""{x:Static materialDesign:DrawerHost.OpenDrawerCommand}"" CommandParameter=""{x:Static Dock.Left}"" Width=""48"" Height=""48"">
        <materialDesign:PackIcon Kind=""Menu"" />
      </Button>
    </StackPanel>
    <!--End Of Left Menu Controller-->
  </materialDesign:DrawerHost>
</smtx:XamlDisplay>");
        }
    }
}