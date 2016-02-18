from figures.base import Figure


class Pie(Figure):
    def __init__(self, radius, arg_degrees, **kwargs):
        super().__init__(**kwargs)
        self.radius = radius
        self.arg_degrees = arg_degrees

    def draw(self, turtle):
        turtle.color(self.color)
        turtle.forward(self.radius)
        turtle.left(90)
        turtle.circle(self.radius, self.arg_degrees)
        turtle.left(90)
        turtle.forward(self.radius)
