import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Farm } from "./app/farm";
import { Chicken } from "./app/chicken";

@Injectable({
  providedIn:'root'
})
export class chickenAPI {
  base: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base = baseUrl;
  }


  getFarms() {
    let url: string = this.base + "Chicken/Farms"
    //console.log(url);

    return this.http.get<Farm[]>(url);
  }

  getFarm(id: number) {
    let url: string = this.base + "Chicken/Farms/" + id;

    return this.http.get<Farm>(url);
  }

  addFarm(name: string ) {
    let url: string = this.base + `Chicken/AddFarm/n=${name}`;
    console.log(url);
    this.http.post(url, {}).subscribe(result => { console.log(result)});
  }

  getChickensByFarm(farmId: number) {
    let url: string = this.base + `Chicken/GetByFarm/${farmId}`;

    return this.http.get<Chicken[]>(url);
  }

  changeSeeds(farmId: number, amount: number) {
    let url: string = this.base + `Chicken/ChangeSeed/farmId=${farmId}&a=${amount}`;

    return this.http.put(url, {});
  }

  feedChicken(farmId: number, chickenId: number) {
    let url: string = this.base + `Chicken/StatsUp/f=${farmId}&c=${chickenId}`;
    return this.http.put(url, {});
  }
}
