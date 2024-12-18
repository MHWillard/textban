using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Xunit;

namespace tests
{
    public class UnitTest
    {
        [Fact]
        public void PassingTest()
        {
            int Add(int x, int y)
            {
                return x + y;
            }

            Assert.Equal(4, Add(2, 2));
        }

        [AvaloniaFact]
        public void Should_Type_Text_Into_TextBox()
        {
            // Setup controls:
            var textBox = new TextBox();
            var window = new Window { Content = textBox };

            // Open window:
            window.Show();

            // Focus text box:
            textBox.Focus();

            // Simulate text input:
            window.KeyTextInput("Hello World");

            // Assert:
            Assert.Equal("Hello World", textBox.Text);
        }
    }
}