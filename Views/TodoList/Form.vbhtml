@Code
    ViewData("Title") = "Form"
End Code

<div class="col-lg-1" >
    <form action="addTodo" method="post" class="form-group">
        <input class="form-control" placeholder="Introduce the todo" name="todo"/>
        <button class="btn btn-primary" type="submit">Save</button>
    </form>
</div>


