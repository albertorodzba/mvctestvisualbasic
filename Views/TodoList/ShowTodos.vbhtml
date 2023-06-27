@Code
    ViewData("Title") = "ShowTodos"
End Code

@For Each todo In ViewData("Items")
    @<h2>@todo.id</h2>
    @<h2>@todo.todo</h2>
    @<h2>@todo.task_created</h2>
    @<h2>@todo.userid</h2>
    @<h2>@todo.completed</h2>

Next
