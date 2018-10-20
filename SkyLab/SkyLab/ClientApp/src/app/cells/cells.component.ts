import { Component } from '@angular/core';

@Component({
  selector: 'app-cells',
  templateUrl: './cells.component.html'
})
export class CellsComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
