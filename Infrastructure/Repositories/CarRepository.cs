using Core.Entities;
using Infrastructure.Data;
using System.Threading.Tasks;
using System.IO;

namespace Infrastructure.Repositories {
    public class CarRepository : GenericRepository<Car> {
        public CarRepository (ApplicationContext context) : base (context) { }

        public async Task UploadImage (byte[] file, string name) {
            var path = $"../Infrastructure/Img/{name}";
            using (FileStream fs = File.Create(path)) {
                await fs.WriteAsync(file, 0, file.Length);
            }
        }
    }
}