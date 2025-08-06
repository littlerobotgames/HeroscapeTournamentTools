var _w_half = width / 2;
var _h_half = height / 2;

draw_set_color(c_black);
draw_rectangle(x - _w_half, y - _h_half, x + _w_half, y + _h_half, true);

draw_set_halign(fa_left);
draw_set_valign(fa_middle);
draw_set_font(fnt_med);

var _blinker = "";

if blinker and typing
{
	_blinker = "|";
}

if text = "" and !typing
{
	draw_text_shadow(x - (_w_half - 10), y, reminder_text, c_ltgray, _w_half - 20);
}
else
{
	if hidden
	{
		var _hidden = "";
		
		repeat(string_length(text))
		{
			_hidden +="*";
		}
		
		draw_text_shadow(x - (_w_half - 10), y, _hidden + _blinker, c_white, _w_half - 20);
	}
	else
	{
		draw_text_shadow(x - (_w_half - 10), y, text + _blinker, c_white, _w_half - 20);
	}
}