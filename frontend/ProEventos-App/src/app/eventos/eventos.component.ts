import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor() { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {

    this.eventos  = [
      {
        Tema: 'Angular 12',
        Local: 'Fortaleza'
      },
      {
        Tema: '.NET 6',
        Local: 'Caucaia'
      },
      {
        Tema: 'Angular e suas novidades',
        Local: 'Iguape'
      }
    ]

  }

}
