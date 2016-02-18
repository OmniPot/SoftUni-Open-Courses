import math
from figures.base import Figure


class Polygon(Figure):
    def __init__(self, radius, num_sides, **kwargs):
        super().__init__(**kwargs)
        self.radius = radius
        self.num_sides = num_sides

    def draw(self, turtle):
        turtle.penup()
        turtle.goto(self.center_x, self.center_y)
        turtle.pendown()
        turtle.color(self.color)
        turtle.setheading(270)

        rotation = 360 / self.num_sides
        side_length = 2 * self.radius * math.sin(180 / self.num_sides)

        for i in range(self.num_sides):
            turtle.left(rotation)
            turtle.forward(side_length)
