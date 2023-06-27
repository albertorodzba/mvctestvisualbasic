@Code
    ViewData("Title") = "TodoItems"

End Code

@For i = 1 To 5
 @<h1>@i</h1>
Next

@Code
    Dim caracteres() As String = ViewData("Items")

    For Each caracter In caracteres
        @<h2>@caracter</h2>
    Next
End Code


