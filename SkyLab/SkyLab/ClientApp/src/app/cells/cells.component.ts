import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from '../../services/app.constants';
import { Router } from '@angular/router';
import { Cell } from '../../services/models';

@Component({
  selector: 'app-cells',
  templateUrl: './cells.component.html'
})

export class CellsComponent {
  public cells: Cell[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    http.get<Cell[]>(baseUrl + ApiRoutes.getCells).subscribe(result => {
      this.cells = result;
    }, error => console.error(error));
  }

  public details(id: number) {
    this.router.navigate(['/cell', id]);
  }
}

