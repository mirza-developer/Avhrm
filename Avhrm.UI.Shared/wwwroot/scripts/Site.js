function checkMediaQueries(dotNetHelper, mediaQueries) {
    function onMediaQueryChange(event, name) {
        dotNetHelper.invokeMethodAsync('OnMediaQueryChanged', name, event.matches);
    }

    mediaQueries.forEach(mq => {
        const mediaQueryList = window.matchMedia(mq.query);
        mediaQueryList.addEventListener('change', event => onMediaQueryChange(event, mq.name));
        
        onMediaQueryChange(mediaQueryList, mq.name);
    });
}