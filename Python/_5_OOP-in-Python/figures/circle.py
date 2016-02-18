from figures.base import Figure


class Circle(Figure):
    def __init__(self, radius, **kwargs):
        super().__init__(**kwargs)
        self.radius = radius

    def draw(self, turtle):
        turtle.penup()
        turtle.goto(self.center_x - self.radius, self.center_y)
        turtle.pendown()
        turtle.color(self.color)
        turtle.circle(self.radius)
