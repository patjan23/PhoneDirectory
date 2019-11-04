using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneDirectory;

namespace PhoneDirectory.Test
{
    [TestClass]
    public class TestPhoneDirectory
    {
        [TestMethod]
        public void TestSaveAsFile_Pass()
        {
            var vm = new PhoneDirectory.ViewModel.PhoneViewModel();
            vm.SaveAsFile();
            Assert.IsTrue(vm.FileName != null);
        }

        [TestMethod]
        public void TestSaveFile_Pass()
        {
            var vm = new PhoneDirectory.ViewModel.PhoneViewModel();
            vm.SaveFile();
            Assert.IsTrue(vm.FileName != null);
        }

        [TestMethod]
        public void TestConstructor_Pass()
        {
            var vm = new PhoneDirectory.ViewModel.PhoneViewModel();           
            Assert.IsTrue(vm.Phonebook != null);
        }
    }
}
