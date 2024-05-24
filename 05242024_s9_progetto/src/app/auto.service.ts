import { Injectable } from '@angular/core';
import { iAuto } from './models/auto';

@Injectable({
  providedIn: 'root',
})
export class AutoService {
  urlJson: string = '../assets/db.json';
  auto: iAuto[] = [];
  twoRandomAuto: iAuto[] = [];
  brand: string[] = [];
  constructor() {
    this.getAutoFromJson();
  }

  async getAutoFromJson(): Promise<void> {
    const response = await fetch(this.urlJson);
    const jsonContent = await response.json();

    this.auto = jsonContent;
  }
  async getAuto(): Promise<iAuto[]> {
    if (this.auto.length === 0) {
      await this.getAutoFromJson();
      return this.auto;
    }
    return Promise.resolve(this.auto);
  }

  async getRandomAuto() {
    this.twoRandomAuto = [];
    for (let i = 0; i < 2; i++) {
      const randomIndex = Math.floor(Math.random() * this.auto.length);
      this.twoRandomAuto.push(this.auto[randomIndex]);
    }

    return this.twoRandomAuto;
  }

  async getBrandsAuto() {
    return Array.from(new Set(this.auto.map((auto) => auto.brandLogo)));
  }

  async getAutoByBrand(brand: string) {
    return this.auto.filter((auto) => auto.brandLogo === brand);
  }
}
