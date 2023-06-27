Imports System.Web.Mvc
Imports MySql.Data

Namespace Controllers
    Public Class TodoListController
        Inherits Controller

        Function TodoItems() As ActionResult
            Dim message As String = "no hay items aqui"
            Dim array(message.Length) As String

            For i = 0 To message.Length - 1
                array(i) = message(i)
            Next

            ViewData("Items") = array


            Return View()
        End Function

        Function Form() As ActionResult
            Return View()
        End Function

        Function ShowTodos() As ActionResult
            Dim todoList = Query()
            ViewData("Items") = todoList
            Return View()
        End Function


        Function addTodo(todo As String) As ActionResult
            Dim todoItem As New TodoItem
            todoItem.todo = todo
            todoItem.completed = False
            todoItem.task_created = Date.Now
            storeNewTodo(todoItem)
            Return RedirectToAction("showTodos", "todoList")
        End Function

        Function Query() As List(Of TodoItem)
            Dim stringConnection = "server=localhost;user=root;password=Nem02183330156;port=3306;database=todoapp"

            Dim connection As New MySqlClient.MySqlConnection(stringConnection)
            connection.Open()

            Dim querystring As String = "select * from todoitems"

            Dim command As New MySqlClient.MySqlCommand(querystring, connection)

            Dim reader As MySqlClient.MySqlDataReader = command.ExecuteReader()

            Dim todoItems As New List(Of TodoItem)

            While reader.Read()
                Dim item As New TodoItem
                item.ID = reader.GetString("id")
                item.todo = reader.GetString("todo")
                item.userId = reader.GetString("userid")
                item.completed = reader.GetString("completed")
                item.task_created = reader.GetString("task_created")

                todoItems.Add(item)
            End While

            connection.Close()
            command.Dispose()
            reader.Close()

            Return todoItems

        End Function

        Function storeNewTodo(item As TodoItem)
            Dim stringConnection = "server=localhost;user=root;password=Nem02183330156;port=3306;database=todoapp"

            Dim connection As New MySqlClient.MySqlConnection(stringConnection)
            connection.Open()

            Dim querystring As String = "insert into todoitems values(NULL, @todo, @task_created,@completed, 3);"

            Dim command As New MySqlClient.MySqlCommand(querystring, connection)

            command.Parameters.AddWithValue("@todo", item.todo)
            command.Parameters.AddWithValue("@task_created", item.task_created)
            command.Parameters.AddWithValue("@completed", item.completed)

            Dim reader As Int32 = command.ExecuteNonQuery()



            connection.Close()
            command.Dispose()

        End Function

    End Class
End Namespace