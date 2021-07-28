import { Component } from "@angular/core";
import { chickenAPI } from "../../chickenAPI.service";
import { Farm } from "../farm";
@Component({
  selector: 'farm-picker',
  templateUrl: 'farm-picker.component.html',
  providers: [chickenAPI]
})

export class FarmPickerComponent {
  farms: Farm[] = [];

  constructor(private api: chickenAPI)
  {
    api.getFarms().subscribe(
      (farms) => {
        //console.log(farms.length);
        for (let i = 0; i < farms.length; i++) {
          let farm = farms[i];
          console.log(farm);
          let f: Farm = { id: farm.id, name: farm.name, seeds: farm.seeds };

          this.farms.push(f);
        }
      }
    )
  }

  addFarm(farmName: string) {
    console.log(farmName);
    //These lines add it to our front-end array
    //let farmName: string = form.form.value.Name;
    let f: Farm = { id: 0, name: farmName, seeds: 100 }
    this.farms.push(f);

    //These lines will add the farm to our database
    //We will need to add in an addFarm in our service
    this.api.addFarm(farmName);
  }
}
