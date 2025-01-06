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

        [AvaloniaFact]
        public void Expander_Should_Have_Four_Category_Dropdowns()
        {
            //Arrange
            //-Set up window with four expanders: Ready, Waiting, Backlog, Done

            //Act
            //-grab expanders in one

            //Assert
            //-iterate: assert each one matches what they expect to match for category

            //Arrange
            /*
            var categories = new ComboBox();
            var window = new Window { Content = categories };
            var category_names = new List<string> { "Ready","Waiting","Backlog","Done" };
            foreach (string c in category_names)
            {
                categories.Items.Add(c);
            }

            //Act
            window.Show();

            //Assert
            //Assert each category section exists and is a dropdown.
            Assert.Equal("Ready", ready_dropdown.Text);
            Assert.Equal("Waiting", waiting_dropdown.Text);
            Assert.Equal("Backlog", backlog_dropdown.Text);
            Assert.Equal("Done", done_dropdown.Text);
            */


        }
    }
}