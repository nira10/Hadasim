import tkinter as tk
import math


def draw_rectangle():  # rectangle is selected
    root.withdraw()
    new_window = tk.Tk()  # create new window
    label = tk.Label(new_window, text="height")
    label.pack()
    entry = tk.Entry(new_window)  # input height
    entry.pack()
    label = tk.Label(new_window, text="width")
    label.pack()
    entry_w = tk.Entry(new_window)  # input width
    entry_w.pack()
    text_widget = tk.Text(new_window, height=10, width=50)
    text_widget.pack()

    def save_rectangle():
        height = int(entry.get())  # save height and width
        width = int(entry_w.get())
        text_widget.delete('1.0', tk.END)
        if (height - width > 5) or (width - height > 5):
            text_widget.insert(tk.END, "area:" + str(height * width))
        else:
            text_widget.insert(tk.END, "perimeter:" + str((height + width) * 2))

    def return_to_root():
        new_window.destroy()  # close new window, back to main
        root.deiconify()

    save_button = tk.Button(new_window, text="save", command=save_rectangle)
    save_button.pack(side=tk.LEFT, padx=5)

    new_window.protocol("WM_DELETE_WINDOW", return_to_root)
    new_window.mainloop()


def draw_triangle():  # triangle is selected
    root.withdraw()
    new_window = tk.Tk()  # create new window
    label = tk.Label(new_window, text="height")
    label.pack()
    entry = tk.Entry(new_window)  # input height
    entry.pack()
    label = tk.Label(new_window, text="width")
    label.pack()
    entry_w = tk.Entry(new_window)  # input width
    entry_w.pack()
    text_widget = tk.Text(new_window, height=10, width=50)
    text_widget.pack()

    def save_triangle():  # save height and width
        height = int(entry.get())
        width = int(entry_w.get())
        text_widget.delete('1.0', tk.END)
        print_triangle_func = lambda: print_triangle(height, width)
        print_perimeter_func = lambda: print_perimeter(height, width)

        def print_perimeter(height, width):  # show perimeter is selected
            hypotenuse = math.sqrt((width / 2) ** 2 + height ** 2)  # Calculation the hypotenuse
            text_widget.insert(tk.END, "perimeter:" + str(hypotenuse * 2 + width))

        def print_triangle(height, width):  # print triangle is selected
            if (width % 2 == 0) or ((width / height) > 2):
                text_widget.insert(tk.END, "cant print this triangle")
            elif (width == 3):
                text_widget.insert(tk.END, " *\n"*(height-1))
                text_widget.insert(tk.END, "*"*width)
            else:
                amount = int(max(1, (height-2)/((width-2)//2)))  # number of rows for each number of *
                first = (height-2)-(((width-2)//2)*amount)  # number of extra rows on top
                text_widget.insert(tk.END, " "*(width//2))
                text_widget.insert(tk.END, "*\n")  # first row
                str = " "*((width//2)-1)+"***\n"  # top extra rows
                text_widget.insert(tk.END, str*first)
                for i in range(1, height-2, 2):  # how many * in this level, odd numbers only
                    for j in range(amount):  # how many same rows for each level
                        if ((i+2) < width):
                            text_widget.insert(tk.END, " "*((width//2)-((i+2)//2))+"*"*(i+2) + "\n")  # print the inside rows
                text_widget.insert(tk.END, "*"*width)  # last row

        print_button = tk.Button(new_window, text="print", command=print_triangle_func)
        print_button.pack(side=tk.LEFT, padx=5)
        perimeter_button = tk.Button(new_window, text="perimeter", command=print_perimeter_func)
        perimeter_button.pack(side=tk.LEFT, padx=5)

    save_button = tk.Button(new_window, text="save", command=save_triangle)
    save_button.pack(side=tk.LEFT, padx=5)

    def return_to_root():
        new_window.destroy()  # close new window, back to main
        root.deiconify()

    new_window.protocol("WM_DELETE_WINDOW", return_to_root)
    new_window.mainloop()


def exit_program():
    root.destroy()  # end running


# create new window
root = tk.Tk()
root.title("select shape")

height = 0
width = 0

label = tk.Label(root, text="Choose one of the options")
label.pack()

# options
rectangle_button = tk.Button(root, text="rectangle", command=draw_rectangle)
rectangle_button.pack(side=tk.LEFT, padx=5)

triangle_button = tk.Button(root, text="triangular", command=draw_triangle)
triangle_button.pack(side=tk.LEFT, padx=5)

exit_button = tk.Button(root, text="exit", command=exit_program)
exit_button.pack(side=tk.LEFT, padx=5)


root.mainloop()
