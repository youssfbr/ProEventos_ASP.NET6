import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

import { Evento } from '@app/models/Evento';

import { EventoService } from '@app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss'],
  // providers: [EventoService]
})
export class EventoListaComponent implements OnInit {

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public larguraImagem = 50;
  public margemImagem = 2;
  public exibirImagem = true;
  private _filtroListado = '';

  modalRef?: BsModalRef;

  constructor(
    private EventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

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

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void {
    this.EventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: () => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Eventos.', 'Erro');
      },
      complete: () => this.spinner.hide()
    });
  }

  /* Modal */ ////////////////////////////////////////////////////////////
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento deletado.', 'Deletado');

  }

  decline(): void {
    this.modalRef?.hide();
  }
  /* Modal Fim */ /////////////////////////////////////////////////////////////

  detalheEvento(id: number): void {
    console.log(id);
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
