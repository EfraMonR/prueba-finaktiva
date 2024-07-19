export interface EventLog {
  id: number;
  fecha: Date;
  descripcion: string;
  tipoEvento: number;
}

export interface EventAdd {
  descripcion: string;
  tipoEvento: number;
}
