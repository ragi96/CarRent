Testing und Qualitätmetriken
========================

CI
-----------------------
Mit GitHub Actions wurde Build Pipeline eingerichtet welche nach jedem commit auf den "main" Branch ausgeführt wird.

Testing
-----------------------
Im Projekt Repository befindet sich im Ordner ./source/tests/ das Testprojekt welches Integration und Unit Tests beinhaltet

Sonarcloud
-----------------------

Sonarcloud wurde auch in den Buildprozess eingebaut um statische Code-Analysen durchzuführen.

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=alert_status)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=security_rating)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=bugs)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=code_smells)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=coverage)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=ncloc)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=sqale_index)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=ragi96_CarRent&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=ragi96_CarRent)

K6 Load Test
-----------------------
<iframe width=700, height=500 frameBorder=0 src="https://htmlpreview.github.io/?https://github.com/ragi96/CarRent/blob/main/artifacts/k6report.html"></iframe>