(function () {
    $(function () {
        const colorSelector = $('#ColorSelector');
        const title = $('.title');
        const section_title = $('.section_title');
        const hrLine = $('.hrLine');

        function ChangeColor(item,color){
            item.css('color', color);
        }

        function ChangeBorderColor(item,color) {
            item.css('border', '1px solid ' + color);
        }

        colorSelector.on('change', function () {
            const color = $('select option').filter(':selected').val();
            ChangeColor(title,color);
            ChangeColor(section_title,color);
            ChangeBorderColor(hrLine,color);
          });
    });
})();