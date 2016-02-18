from figures.base import Figure


class Rectangle(Figure):
    def __init__(self, width, height, **kwargs):
        super().__init__(**kwargs)
        self.width = width
        self.height = height

    def draw(self, turtle):
        left = self.center_x - self.width / 2
        top = self.center_y + self.height / 2

        turtle.penup()
        turtle.goto(left, top)
        turtle.pendown()
        turtle.color(self.color)
        turtle.forward(1)
        turtle.setheading(270)
        for i in range(4):
            turtle.forward(self.height if i % 2 == 0 else self.width)
            turtle.left(90)
