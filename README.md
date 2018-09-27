# har-app

### Hacking
#### Instrucciones para merge
Para hacer merge de escenas evitando conflictos mayores asegurarse de hacer lo siguiente:

Crear el archivo `.git/config`
```
$ >.git/config
```
y colocar el siguiente contenido
```
 [merge]
    tool = unityyamlmerge

    [mergetool "unityyamlmerge"]
    trustExitCode = false
    cmd = '<path to UnityYAMLMerge>' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```