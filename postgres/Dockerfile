FROM postgres:18

# Installazione supporto per i locale e generazione di quello italiano
RUN apt-get update && apt-get install -y locales \
    && sed -i -e 's/# it_IT.UTF-8 UTF-8/it_IT.UTF-8 UTF-8/' /etc/locale.gen \
    && locale-gen

ENV LANG it_IT.UTF-8
ENV LC_ALL it_IT.UTF-8