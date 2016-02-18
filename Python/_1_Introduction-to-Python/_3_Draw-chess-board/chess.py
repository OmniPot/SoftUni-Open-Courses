import turtle

t = turtle.Turtle()

board_squares = 64
row_cells = 8
cell_sides = 4
cell_side = 30
degrees = 90
start_x = -180
start_y = 140
speed = 'fastest'

t.speed(speed)
t.penup()
t.goto(start_x, start_y)
t.pendown()

for cell in range(board_squares):
    if cell % row_cells == 0:
        t.penup()
        t.goto(start_x, start_y - cell_side * (cell // row_cells))
        t.pendown()

    if cell % 2 == 0 if cell // row_cells % 2 == 0 else cell % 2 == 1:
        t.begin_fill()

    for b in range(cell_sides):
        t.forward(cell_side)
        t.left(degrees)

    t.end_fill()
    t.forward(cell_side)

turtle.exitonclick()
