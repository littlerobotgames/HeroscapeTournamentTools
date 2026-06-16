/// @description Accept the inputs and close
global.playerlist[p_id].name = elements[0].text;
global.playerlist[p_id].army_name = elements[1].text;
global.playerlist[p_id].autoby = elements[2].value;

instance_destroy();