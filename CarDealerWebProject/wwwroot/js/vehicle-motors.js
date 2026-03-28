
document.addEventListener('DOMContentLoaded', function () {

    const addMotorButton = document.getElementById('add-motor');
    const motorsContainer = document.getElementById('motors-container');
    const motorBlockTemplate = document.getElementById('motor-template');

    let nextIndex = motorsContainer ? motorsContainer.querySelectorAll('.motor-block').length : 0;

    function wireUpMotorBlock(block) {
        const fuelSelect = block.querySelector('.fuel-select');
        const removeButton = block.querySelector('.remove-motor');

        function updateFieldsVisibility() {
            const fuelField = fuelSelect.value ? fuelSelect.value : '';
            const horsepowerField = block.querySelector('.horsepower-field');
            const engineField = block.querySelector('.engine-field');
            const batteryField = block.querySelector('.battery-field');

            if (fuelField === 'Petrol' || fuelField === 'Diesel') {
                horsepowerField.style.display = '';
                engineField.style.display = '';
                batteryField.style.display = 'none';
            } else if (fuelField === 'Electric') {
                horsepowerField.style.display = '';
                engineField.style.display = 'none';
                batteryField.style.display = '';
            } else {
                horsepowerField.style.display = 'none';
                engineField.style.display = 'none';
                batteryField.style.display = 'none';
            }
        }

        if (fuelSelect) {
            fuelSelect.addEventListener('change', updateFieldsVisibility);
            updateFieldsVisibility();
        }

        if (removeButton) {
            removeButton.addEventListener('click', function () {
                block.remove();
                reindexMotorBlocks();
            });
        }
    }

    function reindexMotorBlocks() {
        const allMotorBlocks = motorsContainer.querySelectorAll('.motor-block');
        allMotorBlocks.forEach((block, index) => {
            const inputs = block.querySelectorAll('input, select, textarea, label, span, [data-valmsg-for]');
            inputs.forEach(element => {
                ['name', 'id', 'for', 'data-valmsg-for', 'data-valmsg-replace'].forEach(attribute => {
                    if (!element.hasAttribute(attribute)) return;
                    const value = element.getAttribute(attribute);
                    if (!value) return;
                    const newValue = value.replace(/Motors\[\d+\]/g, `Motors[${index}]`);
                    if (newValue !== value) element.setAttribute(attribute, newValue);
                });
            });
        });

        nextIndex = allMotorBlocks.length;
    }

    if (addMotorButton && motorBlockTemplate && motorsContainer) {
        addMotorButton.addEventListener('click', function () {

            let html = motorBlockTemplate.innerHTML;
            html = html.replace(/__index__/g, nextIndex.toString());

            const tempContainer = document.createElement('div');
            tempContainer.innerHTML = html;
            const newBlock = tempContainer.firstElementChild;
            motorsContainer.appendChild(newBlock);

            wireUpMotorBlock(newBlock);

            nextIndex++;
        });
    }

    if (motorsContainer) {
        motorsContainer.querySelectorAll('.motor-block').forEach(block => wireUpMotorBlock(block));
    }
});