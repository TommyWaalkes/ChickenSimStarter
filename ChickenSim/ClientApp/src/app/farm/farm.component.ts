import { templateJitUrl } from "@angular/compiler";
import { Component, Input } from "@angular/core";
import { chickenAPI } from "../../chickenAPI.service";
import { Chicken } from "../chicken";
import { Farm } from "../farm";

@Component({
  templateUrl: 'farm.component.html',
  selector: 'farm',
  styleUrls: ['./farm.css'],
  providers: [chickenAPI]
})

export class FarmComponent {
  @Input() id: number = 1;
  farm: Farm = null;
  chickens: Chicken[] = [];
  constructor(private api: chickenAPI) {
    //Since this all in the constructor this should be run upon the page loading 
    this.api.getFarm(this.id).subscribe((result) => {
      console.log(result);
      this.farm = result;
      //This api call should run once a farm is loaded 
      this.api.getChickensByFarm(this.id).subscribe((chickenResults) => {
        this.chickens = chickenResults;
        console.log(chickenResults);
      }

      )
    })
  }

  FarmSeeds() {
    let id = this.farm.id;

    this.api.changeSeeds(id, 1).subscribe(()=>{
      this.farm.seeds += 1;
    })
  }

  Feed(farmId: number, idChicken: number) {
    if (this.farm.seeds > 0) {
      //this.api.changeSeeds(farmId, -1).subscribe(() => {
      //  //Now we want a method that increases the chickens stats

      //})

      this.api.feedChicken(farmId, idChicken).subscribe(() => {
        this.farm.seeds--;
        for (let i = 0; i < this.chickens.length; i++) {
          let c = this.chickens[i];
          if (c.id === idChicken) {
            c.smarts++;
            c.strength++;
            c.speed++;
            c.age++;
          }
        }
      });
    }
  }
}
