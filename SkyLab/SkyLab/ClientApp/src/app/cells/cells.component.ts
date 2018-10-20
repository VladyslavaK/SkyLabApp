import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from '../../services/app.constants';

@Component({
  selector: 'app-cells',
  templateUrl: './cells.component.html'
})
export class CellsComponent {
  public cells: Cells[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Cells[]>(baseUrl + ApiRoutes.getCells).subscribe(result => {
      this.cells = result;
    }, error => console.error(error));
  }
}

interface Cells {
  cellName: string;
  id: number;
  updatedAt: Date;
  comments: string;
}
