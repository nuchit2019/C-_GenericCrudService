# GenericCrudService

GenericCrudService เป็นโปรเจกต์ .NET Web API ที่ใช้ในการจัดการข้อมูล CRUD (Create, Read, Update, Delete) สำหรับ `Product` และ `Customer` โดยใช้ Entity Framework Core และฐานข้อมูลในหน่วยความจำ (In-Memory Database)

## รายละเอียด

โปรเจกต์นี้มี Generic CRUD Service ที่รองรับการทำงานกับ Entity ใดๆ (เช่น `Product`, `Customer`) โดยไม่ต้องเขียนโค้ดซ้ำซ้อนหลายครั้ง สามารถใช้งานได้กับ Entity Framework Core (EF Core) และฐานข้อมูลในหน่วยความจำ (In-Memory Database)

### ข้อดีของ **GenericCrudService**

1. **ลดความซ้ำซ้อนของโค้ด**
   - การใช้ `GenericCrudService` ช่วยลดการเขียนโค้ดซ้ำสำหรับการจัดการ CRUD (Create, Read, Update, Delete) โดยไม่ต้องเขียนเมธอดเหมือนกันซ้ำหลายๆ ครั้งสำหรับแต่ละ Entity (เช่น `Product`, `Customer`) ซึ่งช่วยให้โค้ดสะอาดและง่ายต่อการบำรุงรักษา

2. **การจัดการข้อมูลได้หลายประเภท**
   - `GenericCrudService` ใช้ Generics เพื่อให้สามารถใช้งานได้กับหลายๆ Entity โดยไม่จำกัดเฉพาะประเภทใดประเภทหนึ่ง ซึ่งทำให้สามารถใช้กับ Entity อื่นๆ ได้ง่ายๆ เพียงแค่ระบุชนิดของ Entity ที่ต้องการ เช่น `Product` หรือ `Customer` ทำให้โค้ดสามารถขยายและใช้ซ้ำได้อย่างมีประสิทธิภาพ

3. **รองรับฐานข้อมูลหลายชนิด**
   - การใช้ `DbContext` ของ Entity Framework Core ช่วยให้สามารถใช้ฐานข้อมูลหลายชนิดได้ เช่น ฐานข้อมูลจริง (SQL Server, PostgreSQL) หรือฐานข้อมูลในหน่วยความจำ (In-Memory Database) ซึ่งทำให้สะดวกในการทดสอบและพัฒนา

4. **สามารถทำการทดสอบได้ง่าย**
   - เนื่องจาก `GenericCrudService` เป็นบริการที่สามารถใช้กับหลายๆ Entity และแยกความรับผิดชอบได้ดี ทำให้การเขียน unit test และ integration test ทำได้ง่าย โดยเฉพาะการทดสอบกับฐานข้อมูลในหน่วยความจำ (In-Memory Database) สำหรับการทดสอบการทำงานของ CRUD

5. **ทำให้การบำรุงรักษาระบบง่ายขึ้น**
   - เมื่อมีการเปลี่ยนแปลงในโครงสร้างของ Entity หรือวิธีการทำงานกับฐานข้อมูล คุณไม่ต้องปรับเปลี่ยนโค้ดที่ซ้ำซ้อนในหลายๆ ส่วนของระบบ แค่ปรับเปลี่ยนใน `GenericCrudService` ส่วนเดียวก็เพียงพอ

6. **ปรับขยายได้ง่าย**
   - `GenericCrudService` ออกแบบมาเพื่อให้สามารถขยายฟังก์ชันเพิ่มเติมได้ง่าย เช่น การเพิ่มฟังก์ชันค้นหาขั้นสูง (Search), การกรองข้อมูล (Filtering), หรือการจัดลำดับข้อมูล (Sorting) โดยไม่ต้องเขียนโค้ดซ้ำหลายๆ ครั้ง

7. **มีความยืดหยุ่น**
   - แม้ว่าฟังก์ชันพื้นฐานจะเหมือนกันสำหรับทุกๆ Entity แต่การใช้ `DbSet<TEntity>` และ `DbContext` ของ EF Core ทำให้สามารถใช้ query ที่ซับซ้อน หรือสร้างฟังก์ชันพิเศษเพิ่มเติมได้ตามความต้องการของโปรเจกต์

8. **ความเข้ากันได้กับระบบขนาดใหญ่**
   - ระบบที่มีหลาย Entity และฟังก์ชัน CRUD ที่ซับซ้อน สามารถจัดการได้ดีโดยใช้ `GenericCrudService` ซึ่งทำให้โค้ดง่ายต่อการขยายและทำให้ไม่เกิดความซ้ำซ้อนของโค้ดในระบบขนาดใหญ่

9. **สนับสนุนการทำงานแบบ Asynchronous**
   - การใช้งาน `async` และ `await` กับฟังก์ชัน CRUD ใน `GenericCrudService` ช่วยให้การทำงานแบบ Asynchronous สามารถทำงานได้อย่างราบรื่น ซึ่งช่วยให้แอปพลิเคชันสามารถรองรับการร้องขอจากผู้ใช้หลายๆ คนได้พร้อมกัน (Scalability)

โดยรวมแล้ว `GenericCrudService` ช่วยทำให้โค้ดมีความยืดหยุ่น, ลดการซ้ำซ้อน, และง่ายต่อการขยายและบำรุงรักษา ซึ่งเป็นข้อดีที่สำคัญในระบบที่มีขนาดใหญ่หรือในระบบที่ต้องการการจัดการหลายๆ Entity พร้อมกัน.

## รายละเอียด GenericCrudService
```csharp
using GenericCrudService.Data;  // Import AppDbContext for interacting with the database
using Microsoft.EntityFrameworkCore; // For working with Entity Framework Core

namespace GenericCrudService.Service
{
    // GenericCrudService<TEntity> class implements the IGenericCrudService<TEntity> interface
    // The class is responsible for handling CRUD (Create, Read, Update, Delete) operations for any entity type (TEntity)
    public class GenericCrudService<TEntity> : IGenericCrudService<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context; // The DbContext to interact with the database
        private readonly DbSet<TEntity> _dbSet; // Represents the table of entities in the database

        // Constructor that initializes the context and DbSet
        public GenericCrudService(AppDbContext context)
        {
            _context = context; // Assign the DbContext
            _dbSet = context.Set<TEntity>(); // Get the DbSet for the entity type
        }

        // Method to get all entities from the database asynchronously
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); // Asynchronously retrieve all entities
        }

        // Method to get a single entity by its ID asynchronously
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); // Asynchronously find the entity by its ID
        }

        // Method to create a new entity asynchronously
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity); // Add the entity to the DbSet
            await _context.SaveChangesAsync(); // Save changes to the database
            return entity; // Return the created entity
        }

        // Method to update an existing entity asynchronously
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity); // Update the entity in the DbSet
            await _context.SaveChangesAsync(); // Save changes to the database
            return entity; // Return the updated entity
        }

        // Method to delete an entity by its ID asynchronously
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id); // Find the entity by its ID
            if (entity == null) return false; // Return false if the entity is not found
            _dbSet.Remove(entity); // Remove the entity from the DbSet
            await _context.SaveChangesAsync(); // Save changes to the database
            return true; // Return true to indicate successful deletion
        }
    }

    // The IGenericCrudService<TEntity> interface defines the contract for the CRUD operations
    public interface IGenericCrudService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(); // Method to get all entities asynchronously
        Task<TEntity> GetByIdAsync(int id); // Method to get a single entity by ID asynchronously
        Task<TEntity> CreateAsync(TEntity entity); // Method to create a new entity asynchronously
        Task<TEntity> UpdateAsync(TEntity entity); // Method to update an existing entity asynchronously
        Task<bool> DeleteAsync(int id); // Method to delete an entity by ID asynchronously
    }
}
```

## การติดตั้ง

### ขั้นตอนที่ 1: Clone โปรเจกต์

```bash
git clone https://github.com/your-username/GenericCrudService.git
```

### ขั้นตอนที่ 2: 
เปิดโปรเจกต์ใน Visual Studio หรือเครื่องมือที่คุณใช้
### ขั้นตอนที่ 3: 
ติดตั้ง NuGet Packages ที่จำเป็น
```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson

หรือ
dotnet restore
```
### ขั้นตอนที่ 4: รันโปรเจกต์
```bash
dotnet run
```
โปรเจกต์จะรันที่ URL: http://localhost:5000 หรือ URL ที่กำหนดไว้ใน launchSettings.json
### การใช้งาน API
หลังจากรันแอปพลิเคชันแล้ว คุณสามารถใช้ API สำหรับการจัดการข้อมูล CRUD ผ่าน HTTP Requests ได้ที่ URL ต่อไปนี้:


### Products API
```bash
GET /api/products - ดึงข้อมูลสินค้าทั้งหมด
GET /api/products/{id} - ดึงข้อมูลสินค้าโดยใช้ id
POST /api/products - สร้างสินค้าใหม่
PUT /api/products/{id} - อัปเดตข้อมูลสินค้าตาม id
DELETE /api/products/{id} - ลบสินค้าโดยใช้ id
```

### Customers API
```bash
GET /api/customers - ดึงข้อมูลลูกค้าทั้งหมด
GET /api/customers/{id} - ดึงข้อมูลลูกค้าโดยใช้ id
POST /api/customers - สร้างลูกค้าใหม่
PUT /api/customers/{id} - อัปเดตข้อมูลลูกค้าตาม id
DELETE /api/customers/{id} - ลบลูกค้าโดยใช้ id
```


### ข้อกำหนด
.NET 6 หรือสูงกว่า
Visual Studio หรือเครื่องมือที่รองรับ .NET

### การทดสอบ
โปรเจกต์นี้ใช้ xUnit และ Moq ในการทดสอบหน่วย คุณสามารถใช้คำสั่งต่อไปนี้เพื่อลองทดสอบ:
```bash
dotnet test
```

 