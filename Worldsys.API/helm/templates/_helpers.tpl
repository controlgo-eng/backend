{{/* vim: set filetype=mustache: */}}
{{/*
Expand the name of the chart.
*/}}
{{- define "manifest.name" }}
{{- default .Chart.Name | trunc 63 | trimSuffix "-" -}}
{{- end }}

{{/*
Create a default fully qualified app name.
We truncate at 63 chars because some Kubernetes name fields are limited to this (by the DNS naming spec).
If release name contains chart name it will be used as a full name.
*/}}
{{- define "manifest.fullname" }}
{{- $name := default .Chart.Name -}}
{{- if contains $name .Release.Name }}
{{- .Release.Name | trunc 63 | trimSuffix "-" -}}
{{- else }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" -}}
{{- end }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "manifest.chart" }}
{{- printf "%s-%s" .Chart.Name .Values.buildInformation.buildId | replace "+" "_" | trunc 63 | trimSuffix "-" -}}
{{- end }}

{{/*
Common labels
*/}}
{{- define "manifest.labels" }}
helm.sh/chart: {{ include "manifest.chart" . }}
{{ include "manifest.selectorLabels" . }}
{{- if .Values.buildInformation.buildId }}
version: {{ .Values.buildInformation.appVersion | quote }}
{{- end }}
{{- end }}

{{/*
Annotations
*/}}
{{- define "manifest.defaultAnnotations" }}
branchName: {{ .Values.buildInformation.branchName | quote }}
sourceVersion: {{ .Values.buildInformation.sourceVersion | quote }}
buildId: {{ .Values.buildInformation.buildId | quote }}
author: {{ .Values.buildInformation.author | quote }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "manifest.selectorLabels" }}
app: {{ .Chart.Name | quote }}
{{- end }}

{{/*
Create the name of the service account to use
*/}}
{{- define "manifest.serviceAccountName" }}
{{- if .Values.serviceAccount.create }}
    {{- default (include "manifest.fullname" .) .Values.serviceAccount.name -}}
{{- else }}
    {{- default "default" .Values.serviceAccount.name -}}
{{- end }}
{{- end }}
