
document.addEventListener('DOMContentLoaded', () => {

    const addMotorButon = document.getElementById('add-motor');
    const motorsContainer = document.getElementById('motors-container');
    const template = document.getElementById('motor-template');

    if (addMotorButon) {
        addMotorButon.addEventListener('click', () => {
            const clone = template.firstElementChild.cloneNode(true);
            clone.style.display = 'block';

            const fuelSelect = clone.querySelector('.fuel-select');
            if (fuelSelect) {
                fuelSelect.value = '';
            }

            motorsContainer.appendChild(clone);
        });
    }

    document.addEventListener('change', function (e) {
        if (e.target.classList.contains('fuel-select')) {

            const motorBlock = e.target.closest('.motor-block');
            const fuel = e.target.value;

            const horsepowerField = motorBlock.querySelector('.horsepower-field');
            const engineField = motorBlock.querySelector('.engine-field');
            const batteryField = motorBlock.querySelector('.battery-field');

            horsepowerField.style.display = 'none';
            engineField.style.display = 'none';
            batteryField.style.display = 'none';

            if (!fuel) return;

            horsepowerField.style.display = 'block';

            if (fuel === '2')/*Electric*/ {
                batteryField.style.display = 'block';
            } else {
                engineField.style.display = 'block'; 
            } 
        }
    });

    document.addEventListener('click', function (e) {
        if (e.target.classList.contains('remove-motor')) {
            e.target.closest('.motor-block').remove();
        }
    });

});