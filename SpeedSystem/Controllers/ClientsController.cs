using SpeedSystem.Data;
using SpeedSystem.Helpers;
using SpeedSystem.Models;
using SpeedSystem.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpeedSystem.Controllers
{
    public class ClientsController : Controller
    {
        private SpeedContext db = new SpeedContext();

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            return View(await db.People.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.People.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            //Inicio minha cliente View Model
            ClientViewModel model = new ClientViewModel();
            model.Clients = new Client();

            return View(model);
        }


        //Consultar CEP puxar o endereco
        public JsonResult CorreiosBusca(string cep)
        {
            var ws = new WSCorreios.AtendeClienteClient();
            var res = ws.consultaCEP(cep);

            string[] result = new string[6];
            result[0] = res.end;
            result[1] = res.bairro;
            result[2] = res.cidade;
            result[3] = res.uf;


            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                //Inicia o valor de AvailableCredit como 0,00
                client.Clients.AvailableCredit = 0;
                client.Clients.DataCreate = DateTime.Now;

                /*
                 * Tratando fotografia, pego o arquivo que vem em photoFile, 
                 * faço o upload, a após pego o endereco de armazenamento.
                 */
                var pic = string.Empty;
                var folder = "~/Content/PhotosPerfil";
                if (client.Clients.PhotoFile != null)
                {
                    pic = FilesHelper.UploadPhoto(client.Clients.PhotoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }
                client.Clients.Photo = pic;

                try
                {
                    db.People.Add(client.Clients);
                    await db.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View();
                    throw;
                }

                foreach (var tel in client.Telephones)
                {
                    tel.PersonId = client.Clients.PersonId;
                    db.Telephones.Add(tel);
                    await db.SaveChangesAsync();
                }

                foreach (var address in client.Address)
                {
                    address.PersonId = client.Clients.PersonId;
                    db.Address.Add(address);
                    await db.SaveChangesAsync();
                }

            }

            return RedirectToAction("Index");

        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.People.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PersonId,FirstName,LastName,Email,Photo,Gnere,TypePerson,CpfOrCnpj,DateBirth,AvailableCredit,StatusClient")] Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.Entry(client).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View(client);
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.People.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Client client = await db.People.FindAsync(id);
            db.People.Remove(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)

        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
