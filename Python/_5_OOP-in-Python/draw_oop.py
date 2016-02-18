import os
import sys
import turtle

from loaders import YAMLLoader, JSONLoader
from figures import circle, square, rectangle, pie, polygon

FIGURE_TYPES = {
    "circle": circle.Circle,
    "square": square.Square,
    "rectangle": rectangle.Rectangle,
    "pie": pie.Pie,
    "polygon": polygon.Polygon
}

FILE_LOADERS = {
    ".json": JSONLoader,
    ".yaml": YAMLLoader
}


def main():
    if len(sys.argv) < 2:
        print("Usage: {} input-file.json".format(sys.argv[0]))
        return 1
    try:
        input_data = load_input_data(sys.argv[1])
        figures = create_figures(input_data)
        draw_figures(figures)
    except Exception as e:
        print("Invalid input file provided! Error: " + str(e))
        return 2


def load_input_data(input_filename):
    if not isinstance(input_filename, str) or input_filename == 0:
        raise Exception('Invalid filename!')

    file_ext = os.path.splitext(input_filename)[-1]
    if file_ext[0] is not '.' or file_ext not in FILE_LOADERS:
        raise Exception('Invalid file type!')

    loader = FILE_LOADERS[file_ext]
    return loader.load(loader, input_filename)


def create_figures(input_data: dict):
    result = []
    for f_info in input_data:
        figure_type = f_info['type']
        if figure_type in FIGURE_TYPES:
            figure_class = FIGURE_TYPES[figure_type]
            result.append(figure_class(**f_info))
        else:
            raise ValueError("Unsupported figure")
    return result


def draw_figures(figures):
    t = turtle.Turtle()
    t.speed('slow')

    for figure in figures:
        figure.draw(t)
    turtle.exitonclick()


if __name__ == "__main__":
    sys.exit(main())
