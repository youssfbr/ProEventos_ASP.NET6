import { Component, OnInit } from '@angular/core';
import { EventoService } from './../services/evento.service';

import { Evento } from './../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  // providers: [EventoService]
})
export class EventosComponent implements OnInit {

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public larguraImagem = 50;
  public margemImagem = 2;
  public exibirImagem = true;
  private _filtroListado = '';

  public get filtroLista(): string {
    return this._filtroListado;
  }

  public set filtroLista(value: string) {
    this._filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private eventoService: EventoService) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void {
   this.eventoService.getEventos().subscribe({
     next: (eventos: Evento[]) => {
      this.eventos = eventos;
      this.eventosFiltrados = this.eventos;
    },
    error: (error: any) => console.log(error)
   });
  }

}
