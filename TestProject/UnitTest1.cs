namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task AsincronicoParalelo()
        {
            var task1 = Ejecutar1();
            var task2 = Ejecutar2();
            var task3 = Ejecutar3();
            Task.WaitAll(task1,task2, task3);           
            Assert.IsFalse(false);
        }
        [TestMethod]
        public async Task Asincronico()
        {
            await Ejecutar1();
            await Ejecutar2();
            await Ejecutar3();
            Assert.IsFalse(false);
        }
        private async  Task<bool> Ejecutar1()
        {
            return await Task.Run(() => {
                Thread.Sleep(6980);
                return true;
            });           
        }
        private async Task<bool> Ejecutar2()
        {
            return await Task.Run(() => {
                Thread.Sleep(10);
                return true;
            });            
        }
        private async Task<bool> Ejecutar3()
        {
          return await Task.Run(() => {
                Thread.Sleep(10);
               return true;
            }); 
        }
    }
}