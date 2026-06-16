if active
	{
	draw_set_color(color_back_active);
	}
else
	{
	draw_set_color(color_back);
	}

draw_rectangle(x, y, x+box_width, y+box_height, false);

draw_set_font(fnt_pcard_name_1);
draw_set_halign(fa_left);
draw_set_valign(fa_middle);

if !active
	{
	if text = ""
		{
		draw_set_color(c_gray);
		draw_text(x+8, y+(box_height/2), text_empty);
		}
	else
		{
		draw_set_color(color_text);
		draw_text(x+8, y+(box_height/2), text);
		}
	}
else
	{
	draw_set_color(color_text);
	draw_text(x+8, y+(box_height/2), text+tick);
	}


draw_set_color(c_white);