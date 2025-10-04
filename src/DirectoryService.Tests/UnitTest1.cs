using DirectoryService.Domain.Departments;

namespace DirectoryService.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var depLocs = new List<DepartmentLocation>
            {
                new(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
            };

            var depIdents = new List<DepartmentPosition>
            {
                new(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
            };


            var bossDepIdent = DepartmentIdentifier.Create("head");
            var bossDepPath = DepartmentPath.Create(bossDepIdent.Value, null);

            var depBoss = Department.Create(
                DepartmentName.Create("Boss").Value,
                bossDepIdent.Value,
                null,
                bossDepPath.Value,
                depLocs,
                depIdents);

            var officeDepIdent = DepartmentIdentifier.Create("office");
            var officeDepPath = DepartmentPath.Create(officeDepIdent.Value, depBoss.Value);


            var depOffice = Department.Create(
                DepartmentName.Create("Office").Value,
                officeDepIdent.Value,
                depBoss.Value,
                officeDepPath.Value,
                depLocs,
                depIdents);

            Console.WriteLine("sdds");
        }
    }
}
