import { Component, OnInit, TemplateRef } from '@angular/core';
import { Professor } from '../models/Professor';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css'],
})
export class ProfessoresComponent implements OnInit {
  public ProfessorForm: FormGroup;
  titulo = 'Professores';
  public professorSelecionado!: Professor;
  modalRef?: BsModalRef;

  constructor(private fb: FormBuilder, private modalService: BsModalService) {
    this.criarForm();
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template);
  }
  ngOnInit(): void {}

  criarForm() {
    this.ProfessorForm = this.fb.group({
      nome: ['', Validators.required],
      disciplina: ['', Validators.required],
    });
  }

  public professores = [
    { id: 1, nome: 'Lauro', disciplina: 'Matemática' },
    { id: 2, nome: 'Roberto', disciplina: 'Física' },
    { id: 3, nome: 'Ronaldo', disciplina: 'Português' },
    { id: 4, nome: 'Rodrigo', disciplina: 'Inglês' },
    { id: 5, nome: 'Alexandre', disciplina: 'Programação' },
    { id: 6, nome: 'Fabrício', disciplina: 'Orientação a Objeto' },
  ];

  professorSubmit() {
    console.log(this.ProfessorForm.value);
  }

  professorSelect(professor: Professor) {
    this.professorSelecionado = professor;
    this.ProfessorForm.patchValue(professor);
  }

  voltar() {
    this.professorSelecionado = null;
  }
}
