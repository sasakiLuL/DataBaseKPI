using Npgsql;
using NpgsqlTypes;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Reflection.PortableExecutable;

using NpgsqlConnection connection = new NpgsqlConnection();
connection.ConnectionString = "host=localhost;port=5433;database=adonet_test_db;user id=postgres;password=pass12345";
connection.Open();

static void PrintDataSet(DataSet dataSet)
{
    foreach (DataTable table in dataSet.Tables)
    {
        foreach (DataRow row in table.Rows) 
        {
            foreach (object? item in row.ItemArray)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

var courseSet = new DataSet();

using var dataAdapter = new NpgsqlDataAdapter();

dataAdapter.InsertCommand = new NpgsqlCommand(@"INSERT INTO courses(course_name, date) VALUES (@CourseName, @Date);
                                                SELECT * FROM courses WHERE course_id = currval('courses_course_id_seq');", connection);
dataAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@CourseName", NpgsqlDbType.Varchar, 50) { SourceColumn = "course_name" });
dataAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@Date", NpgsqlDbType.Date) { SourceColumn = "date" });


dataAdapter.SelectCommand = new NpgsqlCommand("SELECT course_id, course_name, date FROM courses", connection);

dataAdapter.UpdateCommand = new NpgsqlCommand("UPDATE courses SET course_name = @CourseName, date = @Date WHERE course_id = @CourseId", connection);
dataAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("@CourseName", NpgsqlDbType.Varchar, 50) { SourceColumn = "course_name" });
dataAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("@CourseId", NpgsqlDbType.Bigint) { SourceColumn = "course_id" });
dataAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("@Date", NpgsqlDbType.Date) { SourceColumn = "date" });

dataAdapter.DeleteCommand = new NpgsqlCommand("DELETE FROM courses WHERE course_id = @CourseId", connection);
dataAdapter.DeleteCommand.Parameters.Add(new NpgsqlParameter("@CourseId", NpgsqlDbType.Bigint) { SourceColumn = "course_id", SourceVersion = DataRowVersion.Original });

dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
dataAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;

dataAdapter.Fill(courseSet, "courses");

PrintDataSet(courseSet);

/*
try
{
    courseSet.Tables["courses"].Rows[0]["course_name"] = "C++ for beginners";
    dataAdapter.Update(courseSet, "courses");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/

/*
try
{
    DataRow newRow = courseSet.Tables["courses"].NewRow();
    newRow["course_name"] = "PHP for beginners";
    newRow["date"] = (new DateOnly(2023, 11, 6)).ToString();
    courseSet.Tables["courses"].Rows.Add(newRow);

    var dataChanges = courseSet.GetChanges();

    PrintDataSet(dataChanges);

    dataAdapter.Update(dataChanges, "courses");

    courseSet.Merge(dataChanges);

    courseSet.AcceptChanges();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/

/*
courseSet.Tables["courses"].Rows[3].Delete();
dataAdapter.Update(courseSet, "courses");
*/

Console.WriteLine();
PrintDataSet(courseSet);