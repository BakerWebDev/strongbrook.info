// JavaScript Document

function loadJWvideoYouTube (movie, w, h, image, autostart) {

	  jwplayer('mediaspace').setup({
		'flashplayer': 'jwplayer/player.swf',
		'file': 'http://www.youtube.com/watch?v=' + movie,
		'controlbar': 'none',
		'autostart': autostart,
		'stretching': 'exactfit',
		'width': w,
		'height': h,
		'image': image
	  });
}

function loadJWvideoLocal (movie, w, h, image, autostart) {

	  jwplayer("mediaspace").setup({
		autostart: autostart,
		flashplayer: "jwplayer/player.swf",
		width: w,
		height: h,
		stretching: 'exactfit',
		controlbar: 'none',
		image: image
	  });

	  jwplayer().load(movie)


}
